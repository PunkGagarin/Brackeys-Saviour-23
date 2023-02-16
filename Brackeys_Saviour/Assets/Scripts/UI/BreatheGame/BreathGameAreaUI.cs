using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace UI.BreatheGame {

    public class BreathGameAreaUI : MonoBehaviour {

        private List<BreatheGameBlock> _blocks = new();

        private float _width;

        [SerializeField]
        private float _blockSpace = 5f;

        [SerializeField]
        private int _blockSize = 20;

        [SerializeField]
        private int _blockDiff = 5;

        [SerializeField]
        private int _offset = 25;

        [SerializeField]
        private BreatheGameBlock _blockPrefab;

        private void Awake() {
            _width = GetComponent<RectTransform>().sizeDelta.x -_offset;
            _blocks = GetComponentsInChildren<BreatheGameBlock>().ToList();
            
            Assert.IsTrue(_blocks.Count == 3);
        }

        //w = 400
        //blockcount = 3
        //400/3 = 133.3e
        //blockSize = 20
        //firstX = 0-113(rnd) 113
        //secondX = 118, 400/2 = 200;

        //1 0 --- 400 / 3 -20 -0 == 113 + 0 = 113 + 5;
        //2 113 --- ((400 - 113 / 2) - 20 ) + 113 == 287/2 = 143.5 - 20 + 113 = 236.5 113---236.5
        //3 236.5 --- ((400 - 236.5/ 1) - 20) + 236.5 == (163.5 - 20) 143.5 + 236.5 = 380

        //118 244 380


        public void SpawnBlocks(int blockCount) {
            float lastPos = _offset;
            for (int i = 0; i < blockCount; i++) {
                var blockDiff = Random.Range(-_blockDiff, _blockDiff + 1);
                float blockSize = _blockSize + blockDiff;
                var spawnX = Random.Range(lastPos, (_width - lastPos) / (blockCount - i) - blockSize + lastPos);
                // Debug.Log($"Block number: {i}, Block spawnX: {spawnX}");
                SpawnBlock(i, spawnX, blockSize);
                lastPos = spawnX + blockSize + _blockSpace;
            }
        }

        private void SpawnBlock(int blockCount, float spawnX, float blockSize) {
            BreatheGameBlock breatheGameBlock = _blocks[blockCount];
            breatheGameBlock.gameObject.SetActive(true);
            
            var blockRectTransform = breatheGameBlock.GetComponent<RectTransform>();
            // var oldRect = blockRectTransform.rect;
            
            // oldRect.x = spawnX;
            // oldRect.width = blockSize;

            var oldAnchorPos = blockRectTransform.anchoredPosition;
            var oldSize = blockRectTransform.sizeDelta;
            oldAnchorPos.x = spawnX;
            oldSize.x = blockSize;

            blockRectTransform.anchoredPosition = oldAnchorPos;
            blockRectTransform.sizeDelta = oldSize;
            
            // blockRectTransform.rect.Set(oldRect.x, oldRect.y, oldRect.width, oldRect.height);
            breatheGameBlock.SaveValues(blockSize);
        }

        public void CleanBlocks() {
            foreach (var block in _blocks) {
                block.gameObject.SetActive(false);
            }
        }

        public void AddBlock(BreatheGameBlock breatheGameBlock) {
            if (_blocks.Exists(el => el.IsInBlock(breatheGameBlock.startVal) ||
                                     el.IsInBlock(breatheGameBlock.endVal))) {
                Debug.Log("There is already a block with same coordinates!");
            }
            _blocks.Add(breatheGameBlock);
        }

        public BreatheGameBlock PickBlock(float sliderValue, float sizeDeltaX) {
            
            var blockPos = sliderValue * _width + sizeDeltaX;
            Debug.Log($"Picking block with slider val: {sliderValue}, blockPosBeforeCalc: {sliderValue * _width} after: {blockPos}");
            return _blocks.FirstOrDefault(el => el.IsInBlock(blockPos));
        }
    }

}
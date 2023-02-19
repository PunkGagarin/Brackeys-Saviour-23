using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Events.UI {

    public static class EventImageFactory {

        private static Dictionary<string, Sprite> _sprites = new();

        private static List<Sprite> _defaultSprites = new();

        public static Sprite GetProperImageForStory(string headerTextText) {
            if (_sprites.Count <= 0) {
                TryLoadSprites();
            }
            if (_sprites.Count <= 0) {
                Debug.LogError("There is a problem with loading sprites or there is no story sprites at all");
            }
            _sprites.TryGetValue(headerTextText, out var sprite);
            return sprite != null ? sprite : GetDefaultSprite();
        }

        private static Sprite GetDefaultSprite() {
            if (_defaultSprites.Count <= 0) {
                TryLoadDefaultSprites();
            }
            if (_defaultSprites.Count <= 0) {
                Debug.LogError("There is a problem with loading defaultSprites!");
            }
            return _defaultSprites[Random.Range(0, _defaultSprites.Count)];
        }

        private static void TryLoadDefaultSprites() {
            _defaultSprites.AddRange( UnityEngine.Resources.LoadAll<Sprite>("GameEventSprites/DefaultSprites").ToList());
        }

        private static void TryLoadSprites() {
            foreach (var sprite in UnityEngine.Resources.LoadAll<Sprite>("GameEventSprites/StorySprites").ToList()) {
                _sprites.Add(sprite.name, sprite);
            }
        }
    }

}
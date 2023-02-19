#EventName: The Lonely Patient

Mr. Johnson has been in the hospital for weeks, recovering from a serious injury. He's feeling lonely and could use some company.

*[Offer to play cards with Mr. Johnson]# Happiness: +1
-> PlayCards
*[Bring Mr. Johnson his favorite snack from the cafeteria.]# Happiness: +2 # Money: -5
-> BringSnack
*[Ask Mr. Johnson if he wants to watch TV together.]# Happiness: +1
-> WatchTV
== PlayCards ==
Mr. Johnson is delighted to have a card game partner. You spend a couple of hours playing and chatting, and he seems to forget his worries for a while.

*[Promise to visit again soon.]# Happiness: +1
-> LeaveRoom
*[Say goodbye and leave.]
-> DONE
== BringSnack ==
Mr. Johnson's face lights up when he sees his favorite snack. You sit and chat with him as he enjoys it, and he seems much more cheerful.

*[Offer to bring him more snacks next time you visit.]# Happiness: +1
-> LeaveRoom
*[Say goodbye and leave.]
-> DONE
== WatchTV ==
You find a channel that Mr. Johnson likes, and you both enjoy watching a movie together. He seems to appreciate the company and the distraction.

*[Promise to come back and watch more TV together.]# Happiness: +1
-> LeaveRoom
*[Say goodbye and leave.]
-> DONE
== LeaveRoom ==
As you're leaving, Mr. Johnson thanks you for keeping him company. You make a mental note to visit him again soon.

-> DONE

-> END
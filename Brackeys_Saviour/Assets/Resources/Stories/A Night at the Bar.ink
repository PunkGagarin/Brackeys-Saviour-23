# EventName: A Night at the Bar

It's a quiet night at the bar, and you're tending to the taps when a patron walks in. He's tall, dark, and handsome, with a bit of a scowl on his face.

* [Strike up a conversation with the patron.]# Friendship: +1
-> Conversation
* [Make a drink for the patron.]# Happiness: +1 # Money: -1
-> Drink
* [Offer the patron some peanuts.]# Happiness: +1 # Money: -1
-> Peanuts

== Conversation ==
You and the patron start chatting, and you find out that he's a musician who's had a rough day. As he talks, you can see the tension in his shoulders start to ease, and by the time he finishes his drink, he seems in much better spirits.

* [Offer to comp the patron's next drink.]# Happiness: +1 # Money: -1
-> CompDrink
* [Bid the patron farewell.]
-> DONE

== Drink ==
You make the patron's drink, and he takes a long sip. A smile breaks out on his face, and he compliments you on your skills.

* [Offer to make another drink.]# Happiness: +1 # Money: -1
-> Drink
* [Bid the patron farewell.]
-> DONE

== Peanuts ==
You offer the patron a bowl of peanuts, and he happily munches on them as he sips his drink.

* [Offer to buy the patron another snack.]# Happiness: +1 # Money: -2
-> Snack
* [Bid the patron farewell.]
-> DONE

== CompDrink ==
The patron is surprised but pleased by your offer to comp his next drink, and he orders another round.

* [Chat with the patron some more.]# Happiness: +1
-> Conversation
* [Bid the patron farewell.]
-> DONE

== Snack ==
The patron accepts your offer of another snack and picks out a bag of chips. He munches on them as you both chat.

* [Offer to buy the patron another drink.]# Happiness: +1 # Money: -1
-> Drink
* [Bid the patron farewell.]
-> DONE

-> END
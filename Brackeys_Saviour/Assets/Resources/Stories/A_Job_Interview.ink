# EventName: A Job Interview

Jenny has a job interview in an hour. She's feeling nervous and could use some advice.

* [Call her best friend] # Happiness: +1 
-> CallFriend
* [Take a walk and clear her mind] 
-> TakeWalk

=== CallFriend ===

Jenny called her best friend, who gave her some encouraging words and wished her good luck. Jenny felt much better and ready to ace the interview.

-> DONE

=== TakeWalk ===

As she was walking, Jenny stumbled upon a quaint coffee shop. She decided to go in and order her favorite drink.

* [Order her favorite drink] # Money: -5 
-> OrderDrink
* [Get a cheaper drink] 
-> CheaperDrink

=== OrderDrink ===

Jenny ordered her favorite drink and sat down to enjoy it. As she was sipping her drink, she noticed the time and realized she was running late for her interview.

# Happiness: +1

-> DONE

=== CheaperDrink ===

Jenny ordered a cheaper drink and sat down to enjoy it. As she was sipping her drink, she noticed a flyer for a job opening that caught her eye.

# Money: -2
# Volunteer: +1

-> DONE

-> END

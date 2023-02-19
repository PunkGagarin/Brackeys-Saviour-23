# EventName: Visitor for Tom

Tom is in the hospital recovering from a car accident. He's feeling lonely and would love some company.

* [Call his best friend and ask him to come to the hospital.]# Happiness: +1 
-> CallFriend
* [Ask the nurse for a book to read.]# Happiness: +1 
-> Book
* [Watch TV]# Happiness: +1 
-> TV

== CallFriend ==
Tom's best friend comes to visit him, and they chat about old times. Tom feels much better and less alone.

* [Promise to stay in touch.]# Happiness: +1 
-> END

== Book ==
The nurse brings Tom a book to read, and he finds himself lost in the story. For a little while, he forgets his worries and is taken to another world.

* [Return the book to the nurse.]
-> DONE

== TV ==
Tom flips through the channels and eventually finds a movie he enjoys. The distraction is welcome, but he still feels lonely.

* [Ask the nurse for a visit from a therapy dog.]# Happiness: +2 
-> TherapyDog
* [Try to take a nap.]
-> DONE

== TherapyDog ==
A therapy dog comes to visit Tom, and he can't help but smile at the friendly pup. The visit brightens his day, and he feels grateful for the distraction.

* [Thank the nurse for arranging the visit.]
-> DONE
-> END
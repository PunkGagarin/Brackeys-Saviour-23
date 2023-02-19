# EventName: The Street Dog

You are walking down a quiet street when you see a stray dog. He looks thin and tired, but when he sees you he wags his tail and approaches you.

* [Pet the dog]# Happiness: +1
-> Pet
* [Ignore the dog and keep walking]
-> KeepWalking

=== Pet ===
You bend down and pet the dog, who licks your hand gratefully. As you stroke his matted fur, you notice that he has a collar on, but no tag.

* [Take the dog to a vet to see if he's microchipped]# Money: -10
-> Vet
* [Take the dog home with you]# Happiness: +2 # Volunteer: +1
-> TakeHome
* [Leave the dog and continue on your walk]
-> KeepWalking

=== Vet ===
The vet scans the dog and finds a microchip. They're able to contact the owner, who comes to pick up the dog. You feel good knowing that you helped reunite the dog with his family.
-> DONE

=== TakeHome ===
The dog is scared at first, but soon warms up to you and your home. After a bath and some food, he falls asleep on your lap. You decide to take him to a shelter the next day to see if they can help find his owner or find him a new home.

* [Take the dog to a shelter]# Volunteer: +2
-> Shelter
* [Decide to keep the dog yourself]# Happiness: +3 # Volunteer: +1
-> KeepDog

=== Shelter ===
The shelter workers are grateful for your help, and the dog is well-behaved and friendly with the other animals. You feel good knowing that you're helping him find a new home.
-> DONE

=== KeepDog ===
You decide to keep the dog and give him a permanent home. He quickly becomes a beloved member of your family, and you can't imagine life without him.

-> DONE

=== KeepWalking ===
You continue on your walk, but can't shake the feeling that you should have done something to help the dog.

* [Go back and take the dog to a shelter]# Volunteer: +1
-> Shelter
* [Continue on your walk]
-> DONE

-> END

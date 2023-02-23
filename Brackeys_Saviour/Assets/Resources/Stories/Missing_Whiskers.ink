# EventName: Missing Whiskers

-> Start

=== Start ===
Lily wakes up and realizes that Whiskers is missing. She feels a sense of panic rising in her chest. What should she do?

* [Search the house]
-> Search
* [Ask the neighbors if they've seen Whiskers]
-> Search

=== Search ===
Lily starts searching the house for Whiskers. She looks under the beds, in the closets, and behind the couch, but she can't find him. She starts to feel desperate. What should she do next?

* [Go outside and search the yard]
-> Neighbors
* [Make flyers to post around the neighborhood]
-> Neighbors

=== Neighbors ===
Lily asks her neighbors if they've seen Whiskers, but no one has. She starts to feel more and more worried. What should she do next?

* [Search the house]
-> Yard
* [Go outside and search the yard]
-> Yard

=== Yard ===
Lily searches the yard, calling Whiskers' name. She hears a faint meowing sound and follows it to a nearby tree. There, she finds Whiskers stuck in the branches. She helps him down and takes him back inside. She feels relieved and happy that she found him.

* [Hug Whiskers and play with him]# Happiness: +2
-> Flyers
* [Give Whiskers some food and water]# Happiness: +1
-> Flyers

=== Flyers ===
Lily makes flyers with a picture of Whiskers and her phone number. She posts them around the neighborhood and waits for a call. Eventually, someone calls to say they found Whiskers and will return him to her. She feels grateful and relieved.

* [Thank the person and wait for Whiskers to be returned]# Happiness: +2
-> Hug
* [Go to pick up Whiskers right away]# Happiness: +1
-> Hug

=== Hug ===
Lily hugs Whiskers and plays with him, feeling happy and grateful that he's back home.# Happiness: +2
->END

=== Feed ===
Lily gives Whiskers some food and water, feeling relieved that he's safe and sound.# Happiness: +1
->END

=== Thank ===
Lily thanks the person who found Whiskers and waits for him to be returned. When he's back home, she feels grateful and happy.# Happiness: +2
->END

=== Pickup ===
Lily goes to pick up Whiskers right away, feeling eager to have him back home.# Happiness: +1
->END

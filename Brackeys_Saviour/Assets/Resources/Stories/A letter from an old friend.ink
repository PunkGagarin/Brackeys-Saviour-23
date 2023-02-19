# EventName: A Letter from an Old Friend

Samantha receives a letter from an old friend she hasn't seen in years. She's excited to catch up, but also a little nervous about what he might want to talk about.

*[Call her friend and set up a meeting.]# Happiness: +1 
-> CallFriend
*[Write a letter back to her friend.]# Happiness: +1 # Money: -2 
-> WriteLetter
*[Ignore the letter and move on.]# Happiness: -1 
-> IgnoreLetter

=== CallFriend ==
Samantha calls her friend and sets up a meeting at a local coffee shop. They spend the afternoon catching up, and Samantha is grateful for the chance to reconnect with an old friend.

* [Agree to meet up again soon.]# Happiness: +1
-> DONE

=== WriteLetter ==
Samantha writes a letter back to her friend, updating him on what she's been up to lately. She spends a bit of money on a nice card and postage, but it's worth it to reach out to someone from her past.

*[Receive a heartfelt response from her friend.]# Happiness: +2
-> DONE

=== IgnoreLetter ==
Samantha ignores the letter and moves on with her life. She wonders what might have been in the letter, but ultimately decides that she's happy with her current situation.

-> DONE
-> END
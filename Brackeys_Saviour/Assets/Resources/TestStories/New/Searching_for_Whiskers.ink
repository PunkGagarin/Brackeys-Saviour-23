# EventName: Searching for Whiskers

Lily is searching for her missing kitten, Whiskers. She's walking down a busy street when she notices a sign for a lost cat.

* [Check the address on the sign] -> CheckAddress
* [Keep walking and search on her own] -> SearchOnOwn

=== CheckAddress ===

Lily found the address on the sign and rang the doorbell. A kind woman answered the door and confirmed that she had found a cat earlier that day. It was not Whiskers, but Lily thanked the woman for her help.

# Happiness: +1

-> DONE

=== SearchOnOwn ===

Lily continued to walk and search on her own. She came across a park and decided to search there.

* [Ask joggers if they've seen Whiskers] # Volunteer: +1 -> AskJoggers
* [Search the park on her own] -> SearchPark

=== AskJoggers ===

Lily approached a group of joggers and asked if they had seen a missing kitten. They hadn't seen Whiskers, but they promised to keep an eye out and let her know if they found anything.

# Happiness: +1

-> DONE

=== SearchPark ===

Lily searched the park but found no sign of Whiskers. She decided to head back home and make some missing cat flyers.

# Happiness: -1
# Money: -5

-> Flyers

=== Flyers ===

Lily spent the rest of the day making flyers and posting them around the neighborhood. The next day, she received a call from a local animal shelter. They had found a lost kitten that matched Whiskers' description. It was indeed her missing kitten!

# Happiness: +2
# Money: -10

-> DONE

-> END

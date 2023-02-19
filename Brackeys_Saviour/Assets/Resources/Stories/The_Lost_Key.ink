# EventName: The Lost Key

You are on your way to an important meeting when you realize that you've lost your house key.

* [Search your pockets and bag]
-> SearchPockets
* [Re-trace your steps]
-> RetraceSteps

=== SearchPockets ===

You frantically search through your pockets and bag, but you can't find your key.

* [Ask a passerby if they've seen your key]
-> AskPasserby
* [Give up and go back home]
-> GiveUp

=== RetraceSteps ===

You re-trace your steps, scanning the ground for any sign of your key.

* [Ask a shop owner if they've seen your key]
-> AskShopOwner
* [Check nearby trash cans]
-> CheckTrashCans

=== AskPasserby ===

You approach a passerby and ask if they've seen your key. They haven't, but they offer to help you look for it.

* [Accept their help]# Volunteer: +1 # Happiness: +1
-> AcceptHelp
* [Decline their help]# Happiness: +1
-> DeclineHelp

=== AskShopOwner ===

You enter a nearby shop and ask the owner if they've seen your key. They haven't, but they offer to keep an eye out for it.

* [Thank the shop owner and continue your search]
-> ContinueSearch
* [Leave the shop and give up]
-> GiveUp

=== CheckTrashCans ===

You rummage through nearby trash cans, hoping to find your key.

* [Find your key in the trash]# Happiness: +2
-> FindKey
* [Don't find your key]
-> NoKey

=== AcceptHelp ===

You and the passerby search for your key together and eventually find it hidden in a nearby bush. You feel grateful for their help and thank them before continuing on your way.# Happiness: +3 # Volunteer: +1
-> END

=== DeclineHelp ===

You continue searching for your key alone, but you can't find it. Eventually, you give up and go back home.# Happiness: -1
-> END

=== ContinueSearch ===

You continue searching for your key, checking every nook and cranny until you finally find it. You feel a sense of relief and joy as you head to your important meeting.# Happiness: +2
-> END

=== GiveUp ===

You give up on finding your key and go back home, feeling frustrated and disappointed.# Happiness: -2
-> END

=== FindKey ===

You're thrilled to have found your key and head to your important meeting feeling relieved and happy.# Happiness: +2
-> END

=== NoKey ===

You don't find your key and have to call a locksmith to let you into your house.# Happiness: -1 # Money: -40
-> END

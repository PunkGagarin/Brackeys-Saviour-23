#EventName: The Lost Child

-> LostChild

===LostChild===
A mother is frantically searching for her lost child in the park. She has to make some quick decisions to find the child as soon as possible.

*[Ask the nearby people for help]# Volunteer: +1
-> AskForHelp
*[Search the playground first]
-> SearchPlayground
*[Call the police]# Money: -10
-> CallPolice

=== AskForHelp ===
The nearby people offered their help to find the child. Together, they searched the park and found the child hiding behind a tree. The mother thanked everyone who helped and left the park with her child.#Volunteers: +2
-> DONE

=== SearchPlayground ===

The mother found a few children playing on the playground and asked if they had seen her child. One of the children had seen the child wandering towards the pond, so the mother went there and found the child sitting near the pond. The mother hugged the child and took him home.#Happiness: +2
-> DONE

=== CallPolice ===

The mother called the police and reported the missing child. After searching the park for a while, the police found the child playing in the sandbox. The mother was relieved to see her child safe and sound, and thanked the police officers for their help.#Happiness: +2
-> DONE

-> END
# EventName: Policeman Protects Family

You are a police officer in a crime-ridden city. Your job is to protect the people, but you know that your own family is in danger. One night, you hear a noise downstairs and you know that someone has broken into your home.

* [Call for backup]# Volunteer: -1 
-> CallBackup
* [Confront the intruder]# Happiness: -3 # Volunteer: +1 
-> ConfrontIntruder
* [Sneak out with your family]# Happiness: +1 # Volunteer: -1 # Money: -10 
-> GoIntoHiding

=== CallBackup ===

You call for backup and wait for your fellow officers to arrive. As you wait, you hear the sound of glass breaking and footsteps coming up the stairs. You realize that you don't have much time.

* [Barricade the door]# Happiness: +1 
-> Barricade
* [Confront the intruder alone]# Happiness: -3 
-> ConfrontAlone

=== Barricade ===

You quickly gather everything you can find and barricade the door. You hear the intruder trying to break in, but the door holds. After a few minutes, you hear the sound of sirens and the intruder runs away.
# MiniGame: Breathe

-> END

=== ConfrontAlone ===

You confront the intruder, but you are outnumbered. You fight bravely, but you are badly injured. Your fellow officers arrive just in time to save your life.
# MiniGame: Breathe

-> END

=== ConfrontIntruder ===

You confront the intruder and manage to subdue him, but not before he shoots your partner. You call for backup and your partner is rushed to the hospital. You realize that the danger to your family is greater than ever.

* [Stay and protect your partner]
-> StayAndProtect
* [Take your family and go into hiding]# Happiness: +4 # Volunteer: -2 # Money: -20
-> GoIntoHiding

=== StayAndProtect ===

You stay with your partner and make sure that he gets the best medical care. After a few weeks, he recovers and you return to work. You know that your family is still in danger, but you are more determined than ever to protect them.

-> END

=== GoIntoHiding ===

You take your family and go into hiding. You spend the next few months living in fear, but eventually, the danger passes. You return to work, knowing that you made the right decision to protect your family.

-> END

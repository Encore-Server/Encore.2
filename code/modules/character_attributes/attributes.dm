//Basic character attributes.
//Shitcode that enables statistical buffs and debuffs by player choice, not dissimilar to tabletop point buy systems.
//Minmaxxing time
/datum/character_attribute
	var/name = "Character Basic Trait"
	var/desc = "Testing Description"
	var/max_points = 50//1 is equivalent to nothing,  while 50 is demigod status; tune accordingly
	var/points = 1
	var/shorthand = "CBT"

/datum/character_attribute/strength
	name = "Strength"
	shorthand = "STR"
	desc = "The physical strength/kinetic power of the character's body or form."
	points = 1

/datum/character_attribute/dexterity
	name = "Dexterity"
	shorthand = "DEX"
	desc = "he fast and flexible capability, fine-tuned input and spatial awareness of the character."
	points = 1

/datum/character_attribute/speed
	name = "Speed"
	shorthand = "SPE"
	desc = "The speed at which the character is able to traverse space."
	points = 1

/datum/character_attribute/intelligence
	name = "Intelligence"
	shorthand = "INT"
	desc = "The summary of the character's factual intellectual prowess."
	points = 1

/datum/character_attribute/piety
	name = "Piety"
	shorthand = "PITY"
	desc = "The divine devotion, capacity and/or importance of the character."
	points = 1

/datum/character_attribute/pneuma
	name = "Pneuma"
	shorthand = "PNEU"
	desc = "The strength of this character's magical/supernatural powers."
	points = 1

/datum/character_attribute/willpower
	name = "Willpower"
	shorthand = "WILL"
	desc = "The character's ability to withstand injury of the mind and soul."
	points = 1

/datum/character_attribute/fortitude
	name = "Fortitude"
	shorthand = "FORT"
	desc = "The durability and resilience of the character's body or form."
	points = 1

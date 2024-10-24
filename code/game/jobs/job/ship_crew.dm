/datum/job/assistant
	title = "Citizen"
	flag = ASSISTANT
	departments = SIMPLEDEPT(DEPARTMENT_CIVILIAN)
	department_flag = SERVICE
	faction = "Station"
	total_positions = -1
	spawn_positions = -1
	intro_prefix = "an"
	supervisors = "the regency of Etgard Keep upon Domotan Isle"
	selection_color = "#949494"
	economic_modifier = 1
	access = list()			//See /datum/job/assistant/get_access()
	minimal_access = list()	//See /datum/job/assistant/get_access()
	outfit = /obj/outfit/job/assistant
	blacklisted_species = list(SPECIES_VAURCA_BREEDER)

/datum/job/assistant/get_access(selected_title)
	if(GLOB.config.assistant_maint && selected_title == "Assistant")
		return list(ACCESS_MAINT_TUNNELS)
	else
		return list()

/obj/outfit/job/assistant
	name = "Traveler"
	jobtype = /datum/job/assistant

	uniform = /obj/item/clothing/under/color/grey
	shoes = /obj/item/clothing/shoes/sneakers/black

/datum/job/visitor
	title = "Traveler"
	flag = VISITOR
	departments = SIMPLEDEPT(DEPARTMENT_CIVILIAN)
	department_flag = SERVICE
	faction = "Station"
	total_positions = -1
	spawn_positions = -1
	supervisors = "the summary of your own conviction and fealty"
	selection_color = "#949494"
	economic_modifier = 1
	access = list()
	minimal_access = list()
	outfit = /obj/outfit/job/visitor
	blacklisted_species = list(SPECIES_VAURCA_BREEDER)

/obj/outfit/job/visitor
	name = "Off-Duty Crew Member"
	jobtype = /datum/job/visitor

	uniform = /obj/item/clothing/under/color/black
	shoes = /obj/item/clothing/shoes/sneakers/black

/obj/outfit/job/visitor/passenger
	name = "Passenger"
	jobtype = /datum/job/passenger

/datum/job/passenger
	title = "Sailor"
	flag = PASSENGER
	departments = SIMPLEDEPT(DEPARTMENT_CIVILIAN)
	department_flag = SERVICE
	faction = "Station"
	total_positions = -1
	spawn_positions = -1
	supervisors = "your Captain and the four seas"
	selection_color = "#949494"
	economic_modifier = 1
	access = list()
	minimal_access = list()
	outfit = /obj/outfit/job/visitor/passenger
	blacklisted_species = list(SPECIES_VAURCA_BREEDER)

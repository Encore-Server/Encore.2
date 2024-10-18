//tree
/obj/structure/flora/tree/willow
	name = "lush willow tree"
	desc = "An immense and wide tree, familiar and comforting in its shade."
	icon = 'icons/obj/flora/biome/willow_tree.dmi'
	layer = 9
	icon_state = "tree_example"
	pixel_x = -32
	stumptype = /obj/structure/flora/stump

/obj/effect/overlay/tree_willow//shadow underlay
	icon = 'icons/obj/flora/biome/willow_tree.dmi'
	icon_state = "shadow"
	layer = TURF_SHADOW_LAYER

/obj/structure/flora/tree/willow/Initialize(mapload)
	. = ..()
	ClearOverlays()
	overlays += /obj/effect/overlay/tree_willow
	icon_state = "tree[rand(1, 5)]"
	return

/obj/structure/flora/bush/meadow_bush
	name = "small bush"
	desc = "A small bush, perhaps trying its best to be a tree one day."
	icon = 'icons/obj/flora/biome/brush.dmi'
	icon_state = "bush1"
	layer = ABOVE_HUMAN_LAYER
	anchored = 1

/obj/structure/flora/bush/meadow_bush/Initialize(mapload)
	. = ..()
	icon_state = "bush[rand(1, 9)]"

	var/static/list/loc_connections = list(
		COMSIG_ATOM_ENTERED = PROC_REF(on_entered),
	)

	AddElement(/datum/element/connect_loc, loc_connections)

/obj/structure/flora/bush/meadow_bush/proc/on_entered(datum/source, atom/movable/arrived, atom/old_loc, list/atom/old_locs)
	SIGNAL_HANDLER

	if(istype(arrived, /mob/living))
		var/mob/living/L = arrived
		to_chat(L, SPAN_NOTICE("You brush through \the [src] really quite loudly."))
		playsound(loc, 'sound/effects/plantshake.ogg', 60, TRUE)
		shake_animation()


/obj/structure/flora/bush/thick_brush
	name = "thick hedge bush"
	desc = "An impassable wall of vines, muck, wood and leaves. A staple of any forest undergrowth."
	icon = 'icons/obj/flora/thick_brush.dmi'
	icon_state = "smooth"
	layer = ABOVE_HUMAN_LAYER
	density = 1
	anchored = 1
	smoothing_flags = SMOOTH_MORE
	canSmoothWith = list(
		/obj/structure/flora/bush/thick_brush,
		/turf/simulated/wall
	)

/obj/structure/cliffside
	name = "jagged cliff face"
	desc = "A difficult-to-scale cliff face uprooted by some gentle, long-term erosion. It's sharp and craggy, but has a few surfaces for grabbing."
	icon = 'icons/turf/smooth/natural/geology.dmi'
	icon_state = "cliff"
	anchored = TRUE
	density = TRUE
	climbable = TRUE

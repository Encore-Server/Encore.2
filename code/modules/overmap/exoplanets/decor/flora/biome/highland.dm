//tree
/obj/structure/flora/tree/ash
	name = "tall ash tree"
	desc = "A prickly and conical ash tree, common at high altitudes and in cold climates."
	icon = 'icons/obj/flora/biome/ash_tree.dmi'
	layer = 9
	icon_state = "tree_example"
	pixel_x = -32
	stumptype = /obj/structure/flora/stump

/obj/effect/overlay/tree_ash//shadow underlay
	icon = 'icons/obj/flora/biome/ash_tree.dmi'
	icon_state = "shadow"
	layer = TURF_SHADOW_LAYER

/obj/structure/flora/tree/tree_ash/Initialize(mapload)
	. = ..()
	ClearOverlays()
	overlays += /obj/effect/overlay/tree_ash
	icon_state = "tree[rand(1, 5)]"
	return

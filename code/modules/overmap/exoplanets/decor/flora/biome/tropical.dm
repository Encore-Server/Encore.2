//tree
/obj/structure/flora/tree/tropical_palm
	name = "tropical palm tree"
	desc = "A tall, slender palm."
	icon = 'icons/obj/flora/biome/palm_tree.dmi'
	layer = 9
	icon_state = "tree_example"
	pixel_x = -32
	stumptype = /obj/structure/flora/stump

/obj/effect/overlay/tree_palm//shadow underlay
	icon = 'icons/obj/flora/biome/palm_tree.dmi'
	icon_state = "shadow"
	layer = TURF_SHADOW_LAYER

/obj/structure/flora/tree/tropical_palm/Initialize(mapload)
	. = ..()
	ClearOverlays()
	overlays += /obj/effect/overlay/tree_palm
	icon_state = "tree[rand(1, 5)]"
	return

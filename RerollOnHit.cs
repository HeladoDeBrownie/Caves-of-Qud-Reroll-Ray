namespace XRL.World.Parts {
    public class helado_RerollOnHit : IPart {
        public override bool FireEvent (Event E) {
            switch (E.ID) {
            case "ProjectileHit":
                GameObject attacker = E.GetGameObjectParameter ("Attacker");
                GameObject defender = E.GetGameObjectParameter ("Defender");

                if (defender.IsPlayer ()) {
                    GameObject apparentTarget = E.GetGameObjectParameter ("ApparentTarget");
                    defender.FireEvent (Event.New ("Die", "Killer", attacker, "Reason", "You were replaced.", "Accidental", defender != apparentTarget)); }
                else {
                    GameObject doppelganger = defender.GetBlueprint ().createOne ();
                    defender.GetAngryAt (attacker);
                    defender.ReplaceWith (doppelganger);

                    if (defender.HasPart ("Brain")) {
                        XRL.Core.XRLCore.Core.Game.ActionManager.AddActiveObject (doppelganger); }

                    AddPlayerMessage (doppelganger.The + doppelganger.DisplayName + " looks good as new!"); }

                break;
            default:
                return base.FireEvent (E); }
            return true; }

        public override void Register (GameObject GO) {
            GO.RegisterPartEvent (this, "ProjectileHit");
            base.Register (GO); } } }

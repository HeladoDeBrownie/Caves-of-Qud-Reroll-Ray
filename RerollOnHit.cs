namespace XRL.World.Parts {
    public class helado_RerollOnHit : IPart {
        public override bool FireEvent (Event E) {
            switch (E.ID) {
            case "ProjectileHit":
                GameObject attacker = E.GetGameObjectParameter ("Attacker");
                GameObject defender = E.GetGameObjectParameter ("Defender");
                GameObject apparentTarget = E.GetGameObjectParameter ("ApparentTarget");
                GameObject doppelganger = defender.GetBlueprint ().createOne ();
                Cell cell = defender.CurrentCell;

                if (defender.IsPlayer ()) {
                    defender.FireEvent (Event.New ("Die", "Killer", attacker, "Reason", "You were replaced.", "Accidental", defender != apparentTarget)); }
                else {
                    defender.Destroy (); }

                cell.AddObject (doppelganger);
                AddPlayerMessage (doppelganger.The + doppelganger.DisplayName + " looks good as new!");
                break;
            default:
                return base.FireEvent (E); }
            return true; }

        public override void Register (GameObject GO) {
            GO.RegisterPartEvent (this, "ProjectileHit");
            base.Register (GO); } } }

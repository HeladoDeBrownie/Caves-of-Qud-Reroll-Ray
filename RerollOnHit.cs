namespace XRL.World.Parts {
    public class helado_RerollOnHit : IPart {
        public override bool FireEvent (Event E) {
            switch (E.ID) {
            case "ProjectileEntering":
                Log ("helado_RerollOnHit: ProjectileEntering");
                break;
            default:
                return base.FireEvent (E); }
            return true; }

        public override void Register (GameObject GO) {
            GO.RegisterPartEvent (this, "ProjectileEntering");
            base.Register (GO); } } }

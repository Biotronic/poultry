import { BaseView } from "components/baseview";
import { IFarm } from "../../model/farm";

export class FarmList extends BaseView {
    public farms: IFarm[];

    bind(): void {
        this.farms = this.service.getFarms().value;
    }
}

import { BaseView } from 'components/baseview';
import { bindable } from 'aurelia-framework';
import { IHouse } from '../../model/farm';

export class HouseList extends BaseView {
    @bindable
    public houses: IHouse[];
}

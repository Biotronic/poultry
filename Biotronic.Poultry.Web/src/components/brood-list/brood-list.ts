import { bindable } from 'aurelia-framework';
import { IBrood } from '../../model/farm';
import {BaseView} from '../baseview';

export class BroodList extends BaseView {
    @bindable
    public broods: IBrood[];
}

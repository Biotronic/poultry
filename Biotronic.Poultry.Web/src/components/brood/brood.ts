import { IBrood } from './../../model/farm';
import { bindable } from 'aurelia-framework';
import {BaseView} from '../baseview';

export class Brood extends BaseView {
    @bindable
    public brood: IBrood;
}

import { PoultryService } from './../services/poultryservice';
import { I18N } from "aurelia-i18n";
import { autoinject } from "aurelia-property-injection";

export abstract class BaseView {
    @autoinject
    protected i18n: I18N;

    @autoinject
    protected service: PoultryService;
}

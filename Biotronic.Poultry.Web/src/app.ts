import { PoultryService } from './services/poultryservice';
import { Router, RouterConfiguration } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';
import { autoinject } from 'aurelia-property-injection';

@autoinject
export class App {
    @autoinject
    private router: Router;
    @autoinject
    private poultryService: PoultryService;

    public configureRouter(config: RouterConfiguration) {
        config.title = 'Foobar!'
        config.map([
            { route: [''], name: 'home', moduleId: PLATFORM.moduleName('pages/common/home/home') }
        ]);
    }

    public signinSuccess(user) {
        let token = user.getAuthResponse().id_token;
        this.poultryService.signIn(token);
    }

    public signout() {
        let token = "";
        this.poultryService.signOut(token);
    }

    public signinError(error) {
    }
}

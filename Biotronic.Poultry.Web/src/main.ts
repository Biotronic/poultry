import { AppSettings } from './config/appsettings';
import { Aurelia } from 'aurelia-framework';
import * as environment from '../config/environment.json';
import { Config } from 'aurelia-api';
import { PLATFORM } from 'aurelia-pal';

export function configure(aurelia: Aurelia): void {
    aurelia.use
        .standardConfiguration()
        .developmentLogging(environment.debug ? 'debug' : 'warn')
        .plugin(PLATFORM.moduleName('aurelia-property-injection'))
        .feature(PLATFORM.moduleName('resources/index'));

    if (environment.testing) {
        aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
    }


    aurelia.use.plugin(PLATFORM.moduleName('aurelia-api'), (config: Config) => {
        for (let endpoint in AppSettings.endpoints) {
            config.registerEndpoint(endpoint, AppSettings.endpoints[endpoint]);
        }
    });

    aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}

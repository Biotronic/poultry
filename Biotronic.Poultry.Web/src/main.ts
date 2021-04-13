import { AppSettings } from './config/appsettings';
import { Aurelia } from 'aurelia-framework';
import { Config } from 'aurelia-api';
import { PLATFORM } from 'aurelia-pal';
import { I18N } from 'aurelia-i18n';

import * as environment from '../config/environment.json';
var resBundle = require('i18next-resource-store-loader?include=\\.json$!./locales/index.js');

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

    aurelia.use.plugin(PLATFORM.moduleName('aurelia-i18n'), (i18n: I18N) => {
        return i18n.setup({
            resources: resBundle,
            lng: 'nb-NO',
            attributes: ['t'],
            fallbackLng: 'nb-NO',
            debug: true,
            backend: {
                loadPath2: './locales/{{lng}}/{{ns}}.json'
            },
            updateMissing: true,
            saveMissing: true
        });
    });

    aurelia.use
        .globalResources(PLATFORM.moduleName('components/google-signin/google-signin'))
        .globalResources(PLATFORM.moduleName('components/farm-list/farm-list'))
        .globalResources(PLATFORM.moduleName('components/house-list/house-list'))
        .globalResources(PLATFORM.moduleName('components/brood-list/brood-list'))
        .globalResources(PLATFORM.moduleName('components/brood/brood'));

    aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}

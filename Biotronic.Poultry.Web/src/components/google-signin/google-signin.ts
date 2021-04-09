import { inject, bindable } from 'aurelia-framework';
import { gapi } from "gapi-script";
import * as environment from '../../../config/environment.json';

function preparePlatform() {
    // https://developers.google.com/identity/sign-in/web/build-button

    // The name of the global function the platform API will call when
    // it's ready.
    const platformCallbackName = 'setGooglePlatformReady';

    // An "API ready" promise that will be resolved when the platform API 
    // is ready.
    const ready = new Promise(resolve => window[platformCallbackName] = resolve);

    // Inject the client id meta tag
    const meta = document.createElement('meta');
    meta.name = 'google-signin-client_id';
    meta.content = environment.logins.google.clientid;
    document.head.appendChild(meta);

    // Inject an async script element to load the google platform API.
    // Notice the callback name is passed as an argument on the query string.
    const script = document.createElement('script');
    script.src = `https://apis.google.com/js/platform.js?onload=${platformCallbackName}`;
    script.async = true;
    script.defer = true;
    document.head.appendChild(script);

    return ready;
}

const platformReady = preparePlatform();

@inject(Element)
export class GoogleSignin {
    @bindable success = googleUser => { };
    @bindable failure = error => { };
    @bindable scope = 'profile email';
    @bindable theme = 'dark';
    @bindable width = 240;
    @bindable height = 50;

    constructor(private element: HTMLElement) {}

    attached() {
        platformReady.then(this.renderButton);
    }

    renderButton = () => {
        gapi.signin2.render(this.element, {
            scope: this.scope,
            width: this.width,
            height: this.height,
            longtitle: true,
            theme: this.theme,
            onsuccess: googleUser => {
                this.success({ googleUser });
            },
            onfailure: error => {
                this.failure({ error });
            }
        });
    }
}

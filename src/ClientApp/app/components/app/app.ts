import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'ARTchive';
        config.map([{
            route: [ '', 'home' ],
            name: 'home',
            settings: { icon: 'home' },
            moduleId: PLATFORM.moduleName('../home/home'),
            nav: true,
            title: 'Home'
        }, {
            route: 'view-submissions',
                name: 'view-submissions',
            settings: { icon: 'education' },
                moduleId: PLATFORM.moduleName('../view-submissions/view-submissions'),
            nav: true,
            title: 'View Submissions'
        }, {
            route: 'application-form',
            name: 'application-form',
            settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../application-form/application-form'),
            nav: true,
                title: 'Application Form'
        }]);

        this.router = router;
    }
}

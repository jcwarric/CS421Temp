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
        },
            // {
            //    route: 'ExhibitsOverviewPage',
            //    name: 'ExhibitsOverviewPage',
            //    settings: { icon: 'th-list' },
            //    moduleId: PLATFORM.moduleName('../ExhibitsOverviewPage/ExhibitsOverviewPage'),
            //    nav: true,
            //    title: 'Exhibits Overview Page'
            //},
            {
                route: 'View1Submission/:item?',
                name: 'View1Submission', 
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../View1Submission/View1Submission'),
                nav: false,
                title: 'View1Submission'
            },
            {
                route: 'CreateExhibit',
                name: 'CreateExhibit',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../CreateExhibit/CreateExhibit'),
                nav: true,
                title: 'Create Exhibit'
            },
            {
                route: 'ViewExhibits',
                name: 'ViewExhibits',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../ViewExhibits/ViewExhibits'),
                nav: true,
                title: 'View Exhibits'
            },
            {
                route: 'UpdateExhibit/:exhibit?',
                name: 'UpdateExhibit',
                settings: { icon: 'th-list' },
                moduleId: PLATFORM.moduleName('../UpdateExhibit/UpdateExhibit'),
                nav: false,
                title: 'Update Exhibit'
            }
        ]);

        this.router = router;
    }
}

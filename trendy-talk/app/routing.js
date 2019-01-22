templatingApp.config(['$locationProvider', '$stateProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider', '$compileProvider',
    function ($locationProvider, $stateProvider, $urlRouterProvider, $urlMatcherFactoryProvider, $compileProvider) {

        //console.log('Appt.Main is now running')
        if (window.history && window.history.pushState) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: true
            }).hashPrefix('!');
        };
        $urlMatcherFactoryProvider.strictMode(false);
        $compileProvider.debugInfoEnabled(false);

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: './views/home/home.html',
                controller: 'HomeController'
            })
            .state('dashboard', {
                url: '/dashboard',
                templateUrl: './views/home/home.html',
                controller: 'HomeController'
            })
            .state('user', {
                url: '/user',
                templateUrl: './views/user/user.html',
                controller: 'UserController'
            })
            .state('about', {
                url: '/about',
                templateUrl: './views/about/about.html',
                controller: 'AboutController'
            })
            .state('Category', {
                url: '/Category',
                templateUrl: './views/MasterPage/Category/Category.html',
                controller: 'CategoryController'
            })
            .state('Country', {
                url: '/Country',
                templateUrl: './views/MasterPage/Country/Country.html',
                controller: 'CountryController'
            })
            .state('AdminPanel', {
                url: '/AdminPanel',
                templateUrl: './views/MasterPage/AdminPanel/AdminPanel.html',
                controller: 'AdminPanelController'
            });

        $urlRouterProvider.otherwise('/home');
    }]); 

import React, { useState, useEffect } from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter as Router } from 'react-router-dom';
import Forside from './pages/Forside';
import ErrorPage from './pages/Error';
import config, { ReactClientConfiguration } from './services/ClientConfiguration';

const Routing = () => {
    const [areRoutesLoaded, setAreRoutesLoaded] = useState<boolean>(false);
    const [addDevRoutes, setAddDevRoutes] = useState<boolean|undefined>(undefined);

    useEffect(() => {
        let isSubscribed = true;
        async function menuSetups() {
            setAddDevRoutes(await setupDevMenu())
            await setupMenu();
            setAreRoutesLoaded(true);
        }
        menuSetups();

        return function cleanup() {
            isSubscribed = false;
        };
    }, [])


    return (
        areRoutesLoaded ?
        (<Router>
            <Switch>
                <Route exact path={MenuSetup[Side.Forside].path} component={Forside} />
                <Route path='*' component={ErrorPage} />
            </Switch>
        </Router>)
        : <div>Indlæser...</div>
    );
}

export const Side =  {
    Forside: 0,
    Error: 99
}

type MenuItem = {
    path: string,
    menuTekst: string,
    menuitem: boolean,
    prefix: boolean
}

export const MenuSetup: MenuItem[] = [];

const setupMenu = async () => {
    MenuSetup[Side.Forside] = {path: "/", menuTekst: "Forside", menuitem: true, prefix: false};
};

const setupDevMenu = async () => {
    try {
        const rcc = await config.getData();
        if (rcc.includeDevRoutes) {
            MenuSetup[Side.Error] = {path: "/fejl", menuTekst: "(Fejlside)", menuitem: true, prefix: false};
        }
        return rcc.includeDevRoutes;
    } catch (error) {
        console.log(error);
        return false;
    }
};


export default Routing;

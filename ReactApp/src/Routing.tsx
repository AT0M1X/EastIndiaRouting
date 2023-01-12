import React, { useState, useEffect } from 'react';
import { Switch, Route } from 'react-router';
import { BrowserRouter as Router } from 'react-router-dom';

import Home from './pages/Home';
import Login from './pages/Login';
import BookingView from './pages/BookingView';
import Receipt from './pages/Receipt';

const Routing = () => {
    const [areRoutesLoaded, setAreRoutesLoaded] = useState<boolean>(false);

    useEffect(() => {
        let isSubscribed = true;
        async function menuSetups() {
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
                <Route exact path={MenuSetup[Side.Home].path} component={Home} />
                <Route exact path={MenuSetup[Side.Login].path} component={Login} />
                <Route exact path={MenuSetup[Side.BookingView].path} component={BookingView} />
                <Route exact path={MenuSetup[Side.Receipt].path} component={Receipt} />
            </Switch>
        </Router>)
        : <div>Reading...</div>
    );
}

export const Side =  {
    Home: 0,
    Login: 1,
    BookingView: 2,
    Receipt: 3
}

type MenuItem = {
    path: string,
    menuTekst: string,
    menuitem: boolean,
    prefix: boolean
}

export const MenuSetup: MenuItem[] = [];

const setupMenu = async () => {
    MenuSetup[Side.Home] = {path: "/", menuTekst: "Home", menuitem: true, prefix: false};
    MenuSetup[Side.Login] = {path: "/login", menuTekst: "Login", menuitem: true, prefix: false};
    MenuSetup[Side.BookingView] = {path: "/bookingview", menuTekst: "BookingView", menuitem: true, prefix: false};
    MenuSetup[Side.Receipt] = {path: "/receipt", menuTekst: "Receipt", menuitem: true, prefix: false};
};

export default Routing;

import React, { useState, useEffect } from "react";
import { Switch, Route } from "react-router";
import { BrowserRouter as Router } from "react-router-dom";

import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import BookingPage from "./pages/BookingPage";
import ReceiptPage from "./pages/ReceiptPage";

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
  }, []);

  return areRoutesLoaded ? (
    <Router>
      <Switch>
        <Route exact path={MenuSetup[Side.Home].path} component={HomePage} />
        <Route exact path={MenuSetup[Side.Login].path} component={LoginPage} />
        <Route
          exact
          path={MenuSetup[Side.Booking].path}
          component={BookingPage}
        />
        <Route
          exact
          path={MenuSetup[Side.Receipt].path}
          component={ReceiptPage}
        />
      </Switch>
    </Router>
  ) : (
    <div>Reading...</div>
  );
};

export const Side = {
  Home: 0,
  Login: 1,
  Booking: 2,
  Receipt: 3,
};

type MenuItem = {
  path: string;
  menuTekst: string;
  menuitem: boolean;
  prefix: boolean;
};

export const MenuSetup: MenuItem[] = [];

const setupMenu = async () => {
  MenuSetup[Side.Home] = {
    path: "/",
    menuTekst: "Home",
    menuitem: true,
    prefix: false,
  };
  MenuSetup[Side.Login] = {
    path: "/login",
    menuTekst: "Login",
    menuitem: true,
    prefix: false,
  };
  MenuSetup[Side.Booking] = {
    path: "/booking",
    menuTekst: "Booking",
    menuitem: true,
    prefix: false,
  };
  MenuSetup[Side.Receipt] = {
    path: "/receipt",
    menuTekst: "Receipt",
    menuitem: true,
    prefix: false,
  };
};

export default Routing;

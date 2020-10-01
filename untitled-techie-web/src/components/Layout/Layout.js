import React from "react";
import Aux from "../../hoc/MyAux";

import classes from "./Layout.css";
const Layout = (props) => (
  <Aux>
    <div>Toolbar, SiderDrawer, Backdrop</div>
    <main className={classes.MainContent}>{props.children}</main>
  </Aux>
);

export default Layout;

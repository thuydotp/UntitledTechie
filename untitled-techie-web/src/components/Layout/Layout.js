import React from "react";
import Aux from "../../hoc/MyAux";

const Layout = (props) => (
  <Aux>
    <div>Toolbar, SiderDrawer, Backdrop</div>
    <main>{props.children}</main>
  </Aux>
);

export default Layout;

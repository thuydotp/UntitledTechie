import React from "react";
import Aux from "../../hoc/MyAux";

import classes from "./Layout.css";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import Form from "react-bootstrap/Form";
import FormControl from "react-bootstrap/FormControl";

const Layout = (props) => (
  <Aux>
    <header
      className={[classes.TopNavbar, classes.FixedTop].join(" ")}
    >
      <Navbar className={"container"} fixed="top">
        <Navbar.Brand href="#">Anita's Techie</Navbar.Brand>
        <Navbar.Toggle />
        <Form inline>
          <FormControl type="text" placeholder="Search" className="mr-sm-2" />
        </Form>
        <Navbar.Collapse className="justify-content-end">
          <Nav.Item>
            <FontAwesomeIcon
              icon="compass"
              size="lg"
              className={classes.TopNavIcon}
            />
          </Nav.Item>
          <Nav.Item>
            <FontAwesomeIcon
              icon="home"
              size="lg"
              className={classes.TopNavIcon}
            />
          </Nav.Item>
          <Nav.Item>
            <FontAwesomeIcon
              icon="inbox"
              size="lg"
              className={classes.TopNavIcon}
            />
          </Nav.Item>
          <Nav.Item>
            <FontAwesomeIcon
              icon="heart"
              size="lg"
              className={classes.TopNavIcon}
            />
          </Nav.Item>
          <Navbar.Text>
            Signed in as: <a href="#">Anita Do</a>
          </Navbar.Text>
        </Navbar.Collapse>
      </Navbar>
    </header>

    <main className={classes.MainContent}>{props.children}</main>
  </Aux>
);

export default Layout;

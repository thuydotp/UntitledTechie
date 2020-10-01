import React from "react";

import Layout from "./components/Layout/Layout";
import Homepage from "./containers/Homepage/Homepage";

import "bootstrap/dist/css/bootstrap.min.css";

import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";

library.add(fas);

function App() {
  return (
    <div>
      <Layout>
        <Homepage />
      </Layout>
    </div>
  );
}

export default App;

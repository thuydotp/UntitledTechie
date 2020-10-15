import React, { Component } from "react";
import Aux from "../../hoc/MyAux";
import Data from "../../data/Data";

import Suggestion from "../../components/Suggestion/Suggestion";
import Stories from "../../components/Stories/Stories";
import Account from "../../components/Account/Account";
import Posts from "../../components/Posts/Posts";

class Homepage extends Component {
  data = Data;

  render() {
    return (
      <Aux>
        <div className="container">
          <div className="row">
            <div className="col-md-8">
              {/* <Stories stories={this.data.stories}></Stories> */}
              <Posts posts={this.data.posts}></Posts>
            </div>
            <div className="col-md-4">
              <Account account={this.data.account}></Account>
              <Suggestion suggestions={this.data.suggestions}></Suggestion>
            </div>
          </div>
        </div>
      </Aux>
    );
  }
}

export default Homepage;

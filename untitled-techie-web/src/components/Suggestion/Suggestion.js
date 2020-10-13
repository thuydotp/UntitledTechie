import React from "react";
import classes from "./Suggestion.css";

const suggestion = (props) => {
  return (
    <div>
      <div className="d-flex justify-content-between">
        <div>Suggestions for you</div>
        <a href="#">See All</a>
      </div>

      {props.suggestions.map((account) => {
        return (
          <div className="d-flex justify-content-between">
            <div className="media">
              <img
                className="mr-3 rounded-circle"
                src="https://picsum.photos/32"
                alt="Generic placeholder image"
              />
              <div className="media-body">
                <a className={["mt-0", classes.Username].join(" ")}>
                  {account.username}
                </a>
                <div className={classes.Fullname}>{account.note}</div>
              </div>
            </div>
            <a href="#">Follow</a>
          </div>
        );
      })}
    </div>
  );
};

export default suggestion;
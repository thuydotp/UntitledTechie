import React from "react";
import classes from "./Suggestion.css";

const suggestion = (props) => {
  return (
    <div>
      <div
        className={[
          "d-flex",
          "justify-content-between",
          classes.SuggestionItem,
        ].join(" ")}
      >
        <div className={classes.SuggestionTitle}>Suggestions for you</div>
        <a href="#" className={classes.SuggestionViewAll}>See All</a>
      </div>

      {props.suggestions.map((account) => {
        return (
          <div
            key={account.id}
            className={[
              "d-flex",
              "justify-content-between",
              classes.SuggestionItem,
            ].join(" ")}
          >
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
                <div className={[classes.Fullname, classes.SuggestionNote].join(" ")}>{account.note}</div>
              </div>
            </div>
            <a href="#" className={classes.FollowLink}>Follow</a>
          </div>
        );
      })}
    </div>
  );
};

export default suggestion;

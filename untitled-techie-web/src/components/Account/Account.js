import React from "react";
import classes from "./Account.css";

const account = (props) => {
  return (
    <div className="media">
      <img
        className="mr-3 rounded-circle"
        src="https://picsum.photos/56"
        alt="Generic placeholder image"
      />
      <div className="media-body">
        <a className={["mt-0", classes.Username].join(" ")}>
          {props.account.username}
        </a>
        <div className={classes.Fullname}>{props.account.fullname}</div>
      </div>
    </div>
  );
};

export default account;
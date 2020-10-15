import React from "react";
import Post from "./Post/Post";

const posts = (props) => {
  return props.posts.map((post) => {
    return <Post author={post.author} caption={post.caption}></Post>;
  });
};

export default posts;

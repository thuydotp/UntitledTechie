const data = {
  account: {
    username: "nuocepanhdao",
    fullname: "Anita Do",
  },
  stories: [
    { author: "doc.sach.moi.ngay" },
    { author: "moingay1trangsach" },
    { author: "tinhte_official" },
    { author: "nguoi.doc.sach" },
  ],
  posts: [
    {
      author: "doc.sach.moi.ngay",
      caption: "Learn to let go #goodquote",
      comments: [
        {
          author: "bot 1",
          description:
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor.",
          subComments: [
            {
              author: "bot 2",
              description:
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia",
            },
            {
              author: "bot 3",
              description:
                "One morning, when Gregor Samsa woke from troubled dreams, he found himself transformed in his bed into a horrible vermin.",
            },
          ],
        },
        {
          author: "bot 1",
          description:
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor.",
          subComments: [
            {
              author: "bot 2",
              description:
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia",
            },
            {
              author: "bot 3",
              description:
                "One morning, when Gregor Samsa woke from troubled dreams, he found himself transformed in his bed into a horrible vermin.",
            },
          ],
        },
        {
          author: "bot 1",
          description:
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor.",
          subComments: [
            {
              author: "bot 2",
              description:
                "Far far away, behind the word mountains, far from the countries Vokalia and Consonantia",
            },
            {
              author: "bot 3",
              description:
                "One morning, when Gregor Samsa woke from troubled dreams, he found himself transformed in his bed into a horrible vermin.",
            },
          ],
        },
      ],
    },
    { author: "doc.sach.moi.ngay", caption: "Learn to let go #goodquote", comments : [] },
    { author: "doc.sach.moi.ngay", caption: "Learn to let go #goodquote", comments : [] },
    { author: "doc.sach.moi.ngay", caption: "Learn to let go #goodquote", comments : [] },
    { author: "doc.sach.moi.ngay", caption: "Learn to let go #goodquote", comments : [] },
  ],
  suggestions: [
    { username: "do.thuynga", note: "Following you" },
    { username: "brenna_blog____", note: "Following you" },
    { username: "lisa_nguyen4112", note: "Suggest for you" },
    { username: "buivanben89", note: "Suggest for you" },
    { username: "thienlocbakery", note: "Following you" },
  ],
};

function create_UUID() {
  var dt = new Date().getTime();
  var uuid = "xxxxxxxx-xxxx-xxxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (
    c
  ) {
    var r = (dt + Math.random() * 16) % 16 | 0;
    dt = Math.floor(dt / 16);
    return (c === "x" ? r : (r & 0x3) | 0x8).toString(16);
  });
  return uuid;
}

function populateId(data) {
  const mainKey = "id";
  for (const key in data) {
    if (data.hasOwnProperty(key) && typeof data[key] === "object") {
      var obj = data[key];
      obj[mainKey] = create_UUID();
      populateId(obj);
    }
  }
}
populateId(data);

export default data;

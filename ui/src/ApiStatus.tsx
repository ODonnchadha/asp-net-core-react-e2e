type Args = {
  status: "idle" | "success" | "error" | "loading"
}

const ApiStatus = ({status}: Args) => {
  switch(status) {
    case "error":
      return <div>COMMUNICATION ERROR...</div>;
    case "idle":
      return <div>IDLE</div>;
    case "loading":
      return <div>LOADING...</div>;
    default:
      throw Error("API status error. Unknown state.");
  }
};

export default ApiStatus;
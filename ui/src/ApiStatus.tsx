type Args = {
  status: "idle" | "success" | "error" | "loading"
}

const ApiStatus = ({status}: Args) => {
  switch(status) {
    case "error":
      return <div>Communication error</div>;
    case "idle":
      return <div>Idle</div>;
    case "loading":
      return <div>Loading...</div>;
    default:
      throw Error("API status error. Unknown state.");
  }
};

export default ApiStatus;
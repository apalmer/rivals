export default {
  longerRoundTime: state => (offset) => {
    return state.remainingRoundTime + offset
  }
}

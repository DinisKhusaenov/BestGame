public interface IStateSwitcher
{
    void StateSwitch<State>() where State : IState;
}

import React, { Component } from 'react';
import NewWindow from 'react-new-window';

class OpenNewWindow extends Component {

    componentDidMount = () => {
        console.log(this.props);
    }

    render() {

        return (
            <NewWindow>
                <button onClick={this.props.close}>Zamknij</button>
                {this.props.htmlCode}
            </NewWindow>
        )
    }
}
export default OpenNewWindow;
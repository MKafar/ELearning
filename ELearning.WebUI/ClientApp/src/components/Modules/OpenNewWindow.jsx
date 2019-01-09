import React, { Component } from 'react';
import NewWindow from 'react-new-window';

class OpenNewWindow extends Component {

    componentDidMount = () => {
        console.log(this.props);
    }

    createMarkup = () => {
        return {__html: this.props.htmlCode};
    }

    render() {

        return (
            <NewWindow >
                <button onClick={this.props.close}>Zamknij</button>
                <div dangerouslySetInnerHTML={this.createMarkup()}>

                </div>
            </NewWindow>
        )
    }
}
export default OpenNewWindow;
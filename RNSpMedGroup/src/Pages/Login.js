import React, { Component } from 'react'
import { StyleSheet, View, TextInput, Button } from 'react-native'

import api from '../Services/Api'

export default class Login extends Component {
    static navigationOptions = {
        header: null
    };
    
    constructor(props) {
        super(props)
        this.state = {
            email: '',
            senha: ''
        }
    }

    _RealizarLogin = async () => {
        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha
        })

        const token = resposta.data
        console.warn(token)

        this.props.navigation.navigate("Consultas")
    }

    render() {
        return (
            <View style={styles.container}>
                <TextInput
                    style={styles.input}
                    placeholder="Email"
                    onChangeText={email => this.setState({ email })}
                />
                <TextInput
                    style={styles.input}
                    placeholder="Senha"
                    secureTextEntry={true}
                    onChangeText={senha => this.setState({ senha })}
                />
                <Button
                    style={styles.button}
                    title="Login"
                    onPress={this._RealizarLogin.bind(this)}
                    color="#000"
                />

            </View>
        )
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: 'white'
    },
    input: {
        width: '80%',
        borderWidth: 1,
        borderColor: 'gray',
        marginBottom: 30,
        color: 'orange'
    },
    button: {
        color: '#000'
    }
})
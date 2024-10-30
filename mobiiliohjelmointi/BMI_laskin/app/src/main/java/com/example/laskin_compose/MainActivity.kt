package com.example.laskin_compose

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Checkbox
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.laskin_compose.ui.theme.Laskin_composeTheme
import kotlin.math.pow
import kotlin.math.roundToLong

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            Laskin_composeTheme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Laskuri(
                        otsikko = "BMI Laskuri",
                        modifier = Modifier.padding(innerPadding)
                    )
                }
            }
        }
    }
}

@Composable
fun Laskuri(otsikko: String, modifier: Modifier = Modifier) {

    var pituus by remember { mutableStateOf("") }
    var paino by remember { mutableStateOf("") }
    var painoindeksi by remember { mutableStateOf<Double?>(null) }

    val (isChecked, setChecked) = remember { mutableStateOf(false) }

    Column(
        modifier = modifier
            .fillMaxSize()
            .padding(16.dp, 24.dp),
            verticalArrangement = Arrangement.Center
    ) {
        Text(
            text = otsikko,
            style = MaterialTheme.typography.headlineLarge,
        )

        Spacer(modifier = Modifier.height(20.dp))

        OutlinedTextField(
            value = pituus,
            onValueChange = { pituus = it },
            label = { Text("Pituus (cm)", fontSize = 20.sp) },
            keyboardOptions = KeyboardOptions.Default.copy(
                keyboardType = KeyboardType.Number
            ),
            modifier = Modifier.fillMaxWidth()
        )

        Spacer(modifier = Modifier.height(20.dp))

        OutlinedTextField(
            value = paino,
            onValueChange = { paino = it },
            label = { Text("Paino (kg)", fontSize = 20.sp) },
            keyboardOptions = KeyboardOptions.Default.copy(keyboardType = KeyboardType.Number),
            modifier = Modifier.fillMaxWidth()
        )

        Row {
            Checkbox(
                checked = isChecked,
                onCheckedChange = { checked -> setChecked(checked) }
            )

            Spacer(modifier = Modifier.height(15.dp))

            Text(text = "Olen aikuinen",
                fontSize = 20.sp,
                modifier = Modifier.padding(top = 15.dp)
            )
        }

        Spacer(modifier = Modifier.height(30.dp))

        Button(onClick = {
            val paino = paino.toDouble()
            val pituus = pituus.toDouble() / 100

            if (isChecked)
                painoindeksi = ((1.3 * paino) / pituus.pow(2.5))
        })

        { Text("Laske", fontSize = 20.sp) }

        Spacer(modifier = Modifier.height(16.dp))

        painoindeksi?.let {
            val pyoristetty = String.format("%.3f", painoindeksi)

            Text(
                text = "Painoindeksi: $pyoristetty",
                fontSize = 20.sp,
                modifier = Modifier.padding(top = 20.dp)
            )
        }
    }
}






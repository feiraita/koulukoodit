package com.example.teht3_8_10

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.gestures.detectTapGestures
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.consumeWindowInsets
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import androidx.compose.material.icons.filled.MoreVert
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.FabPosition
import androidx.compose.material3.FloatingActionButton
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.material3.TopAppBar
import androidx.compose.material3.TopAppBarDefaults
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.input.pointer.pointerInput
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.platform.LocalFocusManager
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.example.teht3_8_10.ui.theme.Teht3_8_10Theme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            Teht3_8_10Theme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                )
                { Greeting("Android") }
            }
        }
    }
}
@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun Greeting(name: String) {
    val lila = Color(0xFF8C74C0)
    val violetti = Color(0xFF46267E)
    // state of the menu
    var expanded by remember { mutableStateOf(false) }

    var screen by remember { mutableStateOf(0) }   // 0 = pääsivu
    var ctx = LocalContext.current.applicationContext  // jos tarvitaan
    val localFocusManager = LocalFocusManager.current

    //pääsivu
    var matkanpituus by remember { mutableStateOf("") }
    var taksa by remember { mutableStateOf<Double?>(null) }

    //sivu 2
    var lahtomaksu by remember { mutableStateOf("") }
    var kilometritaksa by remember { mutableStateOf("")}

    Scaffold(
        modifier = Modifier.fillMaxSize(),
        topBar = {
            TopAppBar(title = { Text(
                "Taksamittari  ",
                color = Color.DarkGray,
                fontWeight = FontWeight.SemiBold)},
                colors = TopAppBarDefaults.mediumTopAppBarColors(containerColor = lila),
                navigationIcon = {
                    IconButton(onClick = { if (screen == 1) screen = 0 }) {
                        Icon(
                            imageVector = Icons.AutoMirrored.Filled.ArrowBack,
                            contentDescription = "Takaisin",
                            tint = violetti
                        )
                    }
                },
                actions = {
                    // 3 vertical dots icon
                    IconButton(onClick = { expanded = true }) {
                        Icon(
                            imageVector = Icons.Default.MoreVert,
                            contentDescription = "Asetukset",
                            tint = violetti
                        )
                    }
                    // drop down menu
                    DropdownMenu(expanded = expanded, onDismissRequest = { expanded = false }
                    ) {
                        DropdownMenuItem(text = {
                            Text("Asetukset",
                                fontSize = 17.sp)}, onClick = {
                            expanded = false
                            screen = 1
                        })
                    }
                }
            )
        },
        floatingActionButtonPosition = FabPosition.End,
        floatingActionButton = {
            FloatingActionButton(onClick = {
                val matka = (matkanpituus.toDoubleOrNull() ?: 0.0)
                val lahtomaksuNum = (lahtomaksu.toDoubleOrNull() ?: 0.0)
                val kilotaksa = (kilometritaksa.toDoubleOrNull() ?: 0.0)

                taksa = (matka * kilotaksa ) + lahtomaksuNum

            },
                containerColor = lila,
                contentColor = violetti
            ){ Text("+", fontSize = 20.sp) }
        },
        content = { innerPadding ->
            Column(
                modifier = Modifier
                    .consumeWindowInsets(innerPadding)
                    .padding(innerPadding)
                    .padding(8.dp)
                    .fillMaxSize()
                    .pointerInput(Unit) {
                        detectTapGestures(onTap = {
                            localFocusManager.clearFocus()
                        })
                    },
                verticalArrangement = Arrangement.Center,
                horizontalAlignment = Alignment.CenterHorizontally
            ) {
                when (screen) {
                    0 -> { //pääsivu
                            TextField(
                                value = matkanpituus,
                                onValueChange = { matkanpituus = it },
                                label = { Text("Matkanpituus (km)", fontSize = 19.sp)},
                                keyboardOptions = KeyboardOptions.Default.copy(
                                    keyboardType = KeyboardType.Number
                                ),
                                textStyle = androidx.compose.ui.text.TextStyle(
                                    fontSize = 25.sp,
                                    color = Color.Black
                                )
                            )
                        Text(
                            text = taksa?.let { "$it €" } ?: "Taksa",
                            modifier = Modifier.padding(30.dp),
                            fontSize = 35.sp,
                            color = violetti
                        )
                    }

                    1 -> { //sivu 2

                        TextField(
                            value = lahtomaksu,
                            onValueChange = { lahtomaksu = it },
                            label = { Text("Lähtömaksu (€)", fontSize = 19.sp) },
                            keyboardOptions = KeyboardOptions.Default.copy(
                                keyboardType = KeyboardType.Number
                            ),
                            textStyle = androidx.compose.ui.text.TextStyle(
                                fontSize = 25.sp,
                                color = Color.Black
                            )
                        )
                        Spacer(modifier = Modifier.height(18.dp))

                        TextField(
                            value = kilometritaksa,
                            onValueChange = { kilometritaksa = it },
                            label = { Text("Kilometritaksa (€/km)", fontSize = 19.sp)},
                            keyboardOptions = KeyboardOptions.Default.copy(
                                keyboardType = KeyboardType.Number
                            ),
                            textStyle = androidx.compose.ui.text.TextStyle(
                                fontSize = 25.sp,
                                color = Color.Black
                            )
                        )
                        Spacer(modifier = Modifier.height(15.dp))
                        IconButton(onClick = {screen = 0},
                            modifier = Modifier
                                .fillMaxWidth(0.45f)
                                .padding(15.dp),
                            colors = androidx.compose.material3.IconButtonDefaults.iconButtonColors(
                                containerColor = lila
                            )
                        ) {
                            Text("Tallenna",
                                fontSize = 18.sp,
                                color = Color.DarkGray,
                                fontWeight = FontWeight.SemiBold
                            )
                        }
                    }
                }
            }
        },
    )
}

@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    Teht3_8_10Theme {
        Greeting("Android")
    }
}
<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/MVR/MPS/GetMotorVehicleRegistrationInfoV2Response"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.MVRMPSAdapter\XMLSchemas\GetMotorVehicleRegistrationInfoV2Response.xsd" workingxmlfile="CA7100XK.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h1">								<properties align="center"/>								<children>									<text fixtext="Разширена справка за МПС по регистрационен номер"/>								</children>							</paragraph>							<newline/>							<template match="n1:GetMotorVehicleRegistrationInfoV2Response" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<template match="n1:Response" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<template match="n1:Results" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<template match="n1:Result" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<template match="n1:VehicleData" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<paragraph paragraphtag="h2">																		<children>																			<text fixtext="Данни за автомобил"/>																		</children>																	</paragraph>																	<template match="n1:RegistrationNumber" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<text fixtext="(А) Регистрационен номер: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:FirstRegistrationDate" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(B) Дата на първа регистрация:">																				<styles font-weight="bold"/>																			</text>																			<text fixtext=" "/>																			<content>																				<format datatype="date"/>																			</content>																		</children>																	</template>																	<template match="n1:VIN" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(E) VIN: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:EngineNumber" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(P5) Номер на двигателя: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:VehicleType" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="Вид на ПС:">																				<styles font-weight="bold"/>																			</text>																			<text fixtext=" "/>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:Model" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(D.1) Марка и модел:">																				<styles font-weight="bold"/>																			</text>																			<text fixtext=" "/>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:TypeApprovalNumber" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(K) Номер  на тип на одобрение: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:ApprovalType" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(D.2) Тип на одобрение (Вариант/Версия): ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:TradeDescription" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(D.3) Търговско наименование: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:Color" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(R) Цвят: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:Category" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(J) Категория: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:OffRoadSymbols" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="Повишена проходимост: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:MassG" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(G) Маса на превозното средство: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="nonNegativeInteger"/>																			</content>																		</children>																	</template>																	<template match="n1:MassF1" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(F.1) Техническа допустима максимална маса: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="nonNegativeInteger"/>																			</content>																		</children>																	</template>																	<template match="n1:Capacity" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(P1) Обем на двигателя: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="nonNegativeInteger"/>																			</content>																		</children>																	</template>																	<template match="n1:MaxPower" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(P2) Максимална мощност: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:Fuel" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(P3) Вид гориво: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<template match="n1:EnvironmentalCategory" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<text fixtext="(V.9) Екологична категория: ">																				<styles font-weight="bold"/>																			</text>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																	<newline/>																	<template match="n1:VehicleDocument" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<paragraph paragraphtag="h3">																				<children>																					<text fixtext="Данни за документ за регистрация"/>																				</children>																			</paragraph>																			<template match="n1:VehDocumentNumber" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Номер на документ за регистрация: ">																						<styles font-weight="bold"/>																					</text>																					<content>																						<format datatype="string"/>																					</content>																				</children>																			</template>																			<newline/>																			<template match="n1:VehDocumentDate" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Дата на издаване: ">																						<styles font-weight="bold"/>																					</text>																					<content>																						<format datatype="date"/>																					</content>																				</children>																			</template>																		</children>																	</template>																</children>															</template>															<newline/>															<template match="n1:OwnersData" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:Owner" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<paragraph paragraphtag="h2">																				<children>																					<text fixtext="Данни за собственик"/>																				</children>																			</paragraph>																			<template match="n1:BulgarianCitizen" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<newline/>																					<condition>																						<children>																							<conditionbranch xpath="string-length( . ) &gt;0">																								<children>																									<text fixtext="Български гражданин">																										<styles text-decoration="underline"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																					<newline/>																					<newline/>																					<template match="n1:PIN" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Единен граждански номер (ЕГН): ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:Names" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="n1:First" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<newline/>																									<text fixtext="Собствено име: ">																										<styles font-weight="bold"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																							<template match="n1:Surname" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<newline/>																									<text fixtext="Бащино име: ">																										<styles font-weight="bold"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																							<template match="n1:Family" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<newline/>																									<text fixtext="Фамилно име: ">																										<styles font-weight="bold"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</template>																			<template match="n1:ForeignCitizen" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<newline/>																					<condition>																						<children>																							<conditionbranch xpath="string-length( . ) &gt; 0">																								<children>																									<text fixtext="Чужденец">																										<styles text-decoration="underline"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																					<newline/>																					<newline/>																					<template match="n1:PIN" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Единен граждански номер (ЕГН): ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:PN" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Личен номер на чужденец (ЛНЧ): ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:NamesCyrillic" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Имена на лицето на кирилица: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:NamesLatin" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Имена на лицето на латиница:">																								<styles font-weight="bold"/>																							</text>																							<text fixtext=" "/>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:Nationality" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Националност:">																								<styles font-weight="bold"/>																							</text>																							<text fixtext=" "/>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</template>																			<template match="n1:Company" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<newline/>																					<condition>																						<children>																							<conditionbranch xpath="string-length( . ) &gt;0">																								<children>																									<text fixtext="Фирма">																										<styles text-decoration="underline"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																					<newline/>																					<newline/>																					<template match="n1:ID" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Идентификатор: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<newline/>																					<template match="n1:Name" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Наименование: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<newline/>																					<template match="n1:NameLatin" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Наименование на латиница: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</template>																		</children>																	</template>																</children>															</template>															<template match="n1:UsersData" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="n1:User" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<newline/>																			<paragraph paragraphtag="h2">																				<children>																					<text fixtext="Данни за потребител"/>																				</children>																			</paragraph>																			<template match="n1:BulgarianCitizen" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<newline/>																					<condition>																						<children>																							<conditionbranch xpath="string-length( . ) &gt;0">																								<children>																									<text fixtext="Български гражданин">																										<styles text-decoration="underline"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																					<newline/>																					<newline/>																					<template match="n1:PIN" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Едине граждански номер (ЕГН): ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:Names" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="n1:First" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<newline/>																									<text fixtext="Собствено име: ">																										<styles font-weight="bold"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																							<template match="n1:Surname" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<newline/>																									<text fixtext="Бащино име: ">																										<styles font-weight="bold"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																							<template match="n1:Family" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<newline/>																									<text fixtext="Фамилно име: ">																										<styles font-weight="bold"/>																									</text>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																					<newline/>																				</children>																			</template>																			<newline/>																			<newline/>																			<template match="n1:ForeignCitizen" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<newline/>																					<condition>																						<children>																							<conditionbranch xpath="string-length( . ) &gt; 0">																								<children>																									<text fixtext="Чужденец">																										<styles text-decoration="underline"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																					<newline/>																					<template match="n1:PIN" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Единен граждански номер (ЕГН): ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:PN" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Личен номер на чужденец (ЛНЧ): ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:NamesCyrillic" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Имена на лицето на кирилица: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:NamesLatin" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Имена на лицето на латиница:">																								<styles font-weight="bold"/>																							</text>																							<text fixtext=" "/>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:Nationality" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<newline/>																							<text fixtext="Националност:">																								<styles font-weight="bold"/>																							</text>																							<text fixtext=" "/>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</template>																			<template match="n1:Company" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<newline/>																					<condition>																						<children>																							<conditionbranch xpath="string-length( . ) &gt;0">																								<children>																									<text fixtext="Фирма">																										<styles text-decoration="underline"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																					<newline/>																					<newline/>																					<template match="n1:ID" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Идентификатор: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<newline/>																					<template match="n1:Name" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Наименование: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<newline/>																					<template match="n1:NameLatin" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext="Наименование на латиница: ">																								<styles font-weight="bold"/>																							</text>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</template>																		</children>																	</template>																</children>															</template>														</children>													</template>												</children>											</template>											<newline/>											<line/>											<newline/>											<table>												<properties border="1"/>												<children>													<tablebody>														<children>															<tablerow>																<children>																	<tablecell headercell="1">																		<properties align="left"/>																		<children>																			<text fixtext="Код на изпълнение на опрацията: "/>																			<newline/>																			<text fixtext="0000-успешна операция;"/>																			<newline/>																			<text fixtext="0100-няма данни отговарящи на условието."/>																			<newline/>																			<text fixtext="Други значения означават възникване на грешка - подлежат на допълнително уточняване"/>																		</children>																	</tablecell>																	<template match="n1:ReturnInformation" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<tablecell>																				<children>																					<template match="n1:ReturnCode" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</template>																</children>															</tablerow>															<tablerow>																<children>																	<tablecell headercell="1">																		<properties align="left"/>																		<children>																			<text fixtext="Описание на грешката (ако е възникнала такава)"/>																		</children>																	</tablecell>																	<template match="n1:ReturnInformation" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<tablecell>																				<children>																					<template match="n1:Info" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</template>																</children>															</tablerow>														</children>													</tablebody>												</children>											</table>										</children>									</template>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>
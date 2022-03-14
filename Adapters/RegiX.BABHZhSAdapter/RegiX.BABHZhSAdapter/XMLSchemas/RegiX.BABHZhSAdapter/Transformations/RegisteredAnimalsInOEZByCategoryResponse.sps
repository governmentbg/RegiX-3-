<?xml version="1.0" encoding="UTF-8"?>
<structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">
	<parameters/>
	<schemasources>
		<namespaces>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/BABH/BABHZhS/RegisteredAnimalsInOEZByCategoryResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="$XML" main="1" schemafile="..\RegisteredAnimalsInOEZByCategoryResponse.xsd" workingxmlfile="RegisteredAnimalsInOEZByCategoryResponse.xml">
				<xmltablesupport/>
				<textstateicons/>
			</xsdschemasource>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate match="/" matchtype="named" parttype="main">
				<children>
					<template match="$XML" matchtype="schemasource">
						<editorproperties elementstodisplay="5"/>
						<children>
							<paragraph>
								<styles max-width="1000px"/>
								<children>
									<paragraph>
										<properties align="center"/>
										<styles font-size="18px" font-weight="bold"/>
										<children>
											<text fixtext="МИНИСТЕРСТВО НА ЗЕМЕДЕЛИЕТО, ХРАНИТЕ И ГОРИТЕ"/>
										</children>
									</paragraph>
									<paragraph>
										<properties align="center"/>
										<styles font-size="14px" font-weight="bold"/>
										<children>
											<text fixtext="БЪЛГАРСКА АГЕНЦИЯ ПО БЕЗОПАСНОСТ НА ХРАНИТЕ"/>
										</children>
									</paragraph>
									<paragraph paragraphtag="h2">
										<properties align="center"/>
										<styles font-size="22px" margin-bottom="0px" padding-bottom="4px"/>
										<children>
											<text fixtext="Справка за животни в ОЕЗ">
												<styles color="black"/>
											</text>
										</children>
									</paragraph>
									<paragraph>
										<properties align="center"/>
										<children>
											<text fixtext="във връзка с чл. 37и, ал. 4 и ал. 5 от Закона за собствеността и ползване на земеделските земи и чл. 99, ал. 2 от Правилника за прилагане  на Закона за собствеността и ползване на земеделските земи"/>
										</children>
									</paragraph>
									<template match="n1:RegisteredAnimalsInOEZByCategoryResponse" matchtype="schemagraphitem">
										<editorproperties elementstodisplay="5"/>
										<children>
											<condition>
												<children>
													<conditionbranch xpath="string-length(.) &gt; 0">
														<children>
															<paragraph>
																<properties align="center"/>
																<children>
																	<template match="n1:ValidDate" matchtype="schemagraphitem">
																		<editorproperties elementstodisplay="5"/>
																		<children>
																			<text fixtext="Към ">
																				<styles font-weight="bold"/>
																			</text>
																			<content>
																				<styles font-weight="bold"/>
																				<format string="DD.MM.YYYY" datatype="dateTime"/>
																			</content>
																			<text fixtext=" г.">
																				<styles font-weight="bold"/>
																			</text>
																		</children>
																	</template>
																	<newline/>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length(n1:FarmerData )">
																				<children>
																					<template match="n1:FarmerData" matchtype="schemagraphitem">
																						<editorproperties elementstodisplay="5"/>
																						<children>
																							<text fixtext="за лицето ">
																								<styles font-weight="bold"/>
																							</text>
																							<template match="n1:FarmerName" matchtype="schemagraphitem">
																								<editorproperties elementstodisplay="5"/>
																								<children>
																									<content>
																										<styles font-weight="bold"/>
																										<format datatype="string"/>
																									</content>
																								</children>
																							</template>
																							<template match="n1:FarmerIdentifier" matchtype="schemagraphitem">
																								<editorproperties elementstodisplay="5"/>
																								<children>
																									<text fixtext=" с ЕГН/ЕИК/Булстат ">
																										<styles font-weight="bold"/>
																									</text>
																									<content>
																										<styles font-weight="bold"/>
																										<format datatype="string"/>
																									</content>
																								</children>
																							</template>
																						</children>
																					</template>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																</children>
															</paragraph>
															<condition>
																<children>
																	<conditionbranch xpath="string-length(n1:FarmsData )&gt;0">
																		<children>
																			<template match="n1:FarmsData" matchtype="schemagraphitem">
																				<editorproperties elementstodisplay="5"/>
																				<children>
																					<template match="n1:FarmInformation" matchtype="schemagraphitem">
																						<editorproperties elementstodisplay="5"/>
																						<children>
																							<newline/>
																							<newline/>
																							<table>
																								<properties border="0" width="100%"/>
																								<children>
																									<tablebody>
																										<children>
																											<tablerow>
																												<children>
																													<tablecell>
																														<styles padding-right="6px" vertical-align="top" width="50%"/>
																														<children>
																															<text fixtext="ОЕЗ:">
																																<styles font-weight="bold"/>
																															</text>
																															<text fixtext=" "/>
																															<template match="n1:FarmType" matchtype="schemagraphitem">
																																<editorproperties elementstodisplay="5"/>
																																<children>
																																	<content>
																																		<format datatype="string"/>
																																	</content>
																																</children>
																															</template>
																														</children>
																													</tablecell>
																													<tablecell>
																														<styles padding-right="6px" vertical-align="top" width="50%"/>
																														<children>
																															<template match="n1:FarmerRole" matchtype="schemagraphitem">
																																<editorproperties elementstodisplay="5"/>
																																<children>
																																	<content>
																																		<styles font-weight="bold" text-transform="uppercase"/>
																																		<format datatype="string"/>
																																	</content>
																																	<text fixtext=":">
																																		<styles text-transform="uppercase"/>
																																	</text>
																																</children>
																															</template>
																														</children>
																													</tablecell>
																												</children>
																											</tablerow>
																											<tablerow>
																												<children>
																													<tablecell>
																														<styles padding-right="6px" vertical-align="top" width="50%"/>
																														<children>
																															<text fixtext="Обект №">
																																<styles font-weight="bold"/>
																															</text>
																															<text fixtext=" "/>
																															<template match="n1:FarmIdentifiers" matchtype="schemagraphitem">
																																<editorproperties elementstodisplay="5"/>
																																<children>
																																	<template match="n1:FarmNumber" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<content>
																																				<format datatype="string"/>
																																			</content>
																																		</children>
																																	</template>
																																	<template match="n1:OldFarmNumber" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<text fixtext=" /стар "/>
																																			<content>
																																				<format datatype="string"/>
																																			</content>
																																			<text fixtext="/"/>
																																		</children>
																																	</template>
																																</children>
																															</template>
																														</children>
																													</tablecell>
																													<tablecell>
																														<styles padding-right="6px" vertical-align="top" width="50%"/>
																														<children>
																															<template match="$XML" matchtype="schemasource">
																																<editorproperties elementstodisplay="5"/>
																																<children>
																																	<template match="n1:RegisteredAnimalsInOEZByCategoryResponse" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<template match="n1:FarmerData" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<template match="n1:FarmerName" matchtype="schemagraphitem">
																																						<editorproperties elementstodisplay="5"/>
																																						<children>
																																							<content>
																																								<format datatype="string"/>
																																							</content>
																																						</children>
																																					</template>
																																					<template match="n1:FarmerIdentifier" matchtype="schemagraphitem">
																																						<editorproperties elementstodisplay="5"/>
																																						<children>
																																							<text fixtext=", "/>
																																							<text fixtext="ЕГН/Булстат:">
																																								<styles font-weight="bold"/>
																																							</text>
																																							<text fixtext=" "/>
																																							<content>
																																								<format datatype="string"/>
																																							</content>
																																						</children>
																																					</template>
																																				</children>
																																			</template>
																																		</children>
																																	</template>
																																</children>
																															</template>
																														</children>
																													</tablecell>
																												</children>
																											</tablerow>
																											<tablerow>
																												<children>
																													<tablecell>
																														<styles padding-right="6px" vertical-align="top" width="50%"/>
																														<children>
																															<text fixtext="Адрес на ОЕЗ: ">
																																<styles font-weight="bold"/>
																															</text>
																															<template match="n1:FarmAddress" matchtype="schemagraphitem">
																																<editorproperties elementstodisplay="5"/>
																																<children>
																																	<template match="n1:DistrictName" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<text fixtext="обл. "/>
																																			<content>
																																				<format datatype="string"/>
																																			</content>
																																		</children>
																																	</template>
																																	<template match="n1:MunicipalityName" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<text fixtext=", общ. "/>
																																			<content>
																																				<format datatype="string"/>
																																			</content>
																																		</children>
																																	</template>
																																	<template match="n1:SettlementName" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<text fixtext=", гр./с. "/>
																																			<content>
																																				<format datatype="string"/>
																																			</content>
																																		</children>
																																	</template>
																																	<template match="n1:AddressDescription" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<text fixtext=", "/>
																																			<content>
																																				<format datatype="string"/>
																																			</content>
																																		</children>
																																	</template>
																																</children>
																															</template>
																														</children>
																													</tablecell>
																													<tablecell>
																														<styles padding-right="6px" vertical-align="top" width="50%"/>
																														<children>
																															<template match="$XML" matchtype="schemasource">
																																<editorproperties elementstodisplay="5"/>
																																<children>
																																	<template match="n1:RegisteredAnimalsInOEZByCategoryResponse" matchtype="schemagraphitem">
																																		<editorproperties elementstodisplay="5"/>
																																		<children>
																																			<template match="n1:FarmerData" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<template match="n1:Address" matchtype="schemagraphitem">
																																						<editorproperties elementstodisplay="5"/>
																																						<children>
																																							<template match="n1:DistrictName" matchtype="schemagraphitem">
																																								<editorproperties elementstodisplay="5"/>
																																								<children>
																																									<text fixtext="обл. "/>
																																									<content>
																																										<format datatype="string"/>
																																									</content>
																																								</children>
																																							</template>
																																							<template match="n1:MunicipalityName" matchtype="schemagraphitem">
																																								<editorproperties elementstodisplay="5"/>
																																								<children>
																																									<text fixtext=", общ. "/>
																																									<content>
																																										<format datatype="string"/>
																																									</content>
																																								</children>
																																							</template>
																																							<template match="n1:SettlementName" matchtype="schemagraphitem">
																																								<editorproperties elementstodisplay="5"/>
																																								<children>
																																									<text fixtext=", гр./с. "/>
																																									<content>
																																										<format datatype="string"/>
																																									</content>
																																								</children>
																																							</template>
																																							<template match="n1:AddressDescription" matchtype="schemagraphitem">
																																								<editorproperties elementstodisplay="5"/>
																																								<children>
																																									<text fixtext=", "/>
																																									<content>
																																										<format datatype="string"/>
																																									</content>
																																								</children>
																																							</template>
																																						</children>
																																					</template>
																																				</children>
																																			</template>
																																		</children>
																																	</template>
																																</children>
																															</template>
																														</children>
																													</tablecell>
																												</children>
																											</tablerow>
																										</children>
																									</tablebody>
																								</children>
																							</table>
																							<newline/>
																							<table>
																								<properties border="1" width="100%"/>
																								<styles border-collapse="collapse"/>
																								<children>
																									<tableheader>
																										<children>
																											<tablerow>
																												<children>
																													<tablecell headercell="1">
																														<properties align="center" width="302"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="Вид и категория животни"/>
																														</children>
																													</tablecell>
																													<tablecell headercell="1">
																														<properties align="center"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="Брой животни"/>
																														</children>
																													</tablecell>
																													<tablecell headercell="1">
																														<properties align="center"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="Коефициент за приравняване"/>
																														</children>
																													</tablecell>
																													<tablecell headercell="1">
																														<properties align="center"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="Брой животински единици (кол. 2 х кол. 3)"/>
																														</children>
																													</tablecell>
																												</children>
																											</tablerow>
																											<tablerow>
																												<children>
																													<tablecell headercell="1">
																														<properties align="center" width="302"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="1"/>
																														</children>
																													</tablecell>
																													<tablecell headercell="1">
																														<properties align="center"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="2"/>
																														</children>
																													</tablecell>
																													<tablecell headercell="1">
																														<properties align="center"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="3"/>
																														</children>
																													</tablecell>
																													<tablecell headercell="1">
																														<properties align="center"/>
																														<styles padding-left="6px" padding-right="6px" text-align="center"/>
																														<children>
																															<text fixtext="4"/>
																														</children>
																													</tablecell>
																												</children>
																											</tablerow>
																										</children>
																									</tableheader>
																									<tablebody>
																										<children>
																											<template match="n1:AnimalsByCategories" matchtype="schemagraphitem">
																												<editorproperties elementstodisplay="5"/>
																												<children>
																													<template match="n1:AnimalCategory" matchtype="schemagraphitem">
																														<editorproperties elementstodisplay="5"/>
																														<children>
																															<tablerow>
																																<children>
																																	<tablecell>
																																		<properties height="24" width="302"/>
																																		<styles padding-left="6px" padding-right="6px"/>
																																		<children>
																																			<template match="n1:CategoryCode" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<content>
																																						<format datatype="string"/>
																																					</content>
																																					<text fixtext=". "/>
																																				</children>
																																			</template>
																																			<template match="n1:CategoryName" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<content>
																																						<format datatype="string"/>
																																					</content>
																																				</children>
																																			</template>
																																		</children>
																																	</tablecell>
																																	<tablecell>
																																		<properties align="center" height="24"/>
																																		<styles padding-left="6px" padding-right="6px"/>
																																		<children>
																																			<template match="n1:AnimalsCount" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<content>
																																						<format datatype="long"/>
																																					</content>
																																				</children>
																																			</template>
																																		</children>
																																	</tablecell>
																																	<tablecell>
																																		<properties align="center" height="24"/>
																																		<styles padding-left="6px" padding-right="6px"/>
																																		<children>
																																			<template match="n1:AnimalUnitFactor" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<content>
																																						<format datatype="double"/>
																																					</content>
																																				</children>
																																			</template>
																																		</children>
																																	</tablecell>
																																	<tablecell>
																																		<properties align="center" height="24"/>
																																		<styles padding-left="6px" padding-right="6px"/>
																																		<children>
																																			<template match="n1:AnimalUnits" matchtype="schemagraphitem">
																																				<editorproperties elementstodisplay="5"/>
																																				<children>
																																					<content>
																																						<format datatype="double"/>
																																					</content>
																																				</children>
																																			</template>
																																		</children>
																																	</tablecell>
																																</children>
																															</tablerow>
																														</children>
																														<sort>
																															<key match="n1:CategoryCode" datatype="Number"/>
																														</sort>
																													</template>
																												</children>
																											</template>
																										</children>
																									</tablebody>
																									<tablefooter>
																										<children>
																											<tablerow>
																												<children>
																													<tablecell>
																														<properties colspan="3" height="24" width="302"/>
																														<children>
																															<text fixtext=" Общо ЖЕ">
																																<styles font-weight="bold"/>
																															</text>
																														</children>
																													</tablecell>
																													<tablecell>
																														<properties align="center" height="24"/>
																														<children>
																															<autocalc xpath="format-number(sum(n1:AnimalsByCategories/n1:AnimalCategory/n1:AnimalUnits), &apos;#.00&apos;)"/>
																														</children>
																													</tablecell>
																												</children>
																											</tablerow>
																										</children>
																									</tablefooter>
																								</children>
																							</table>
																							<newline/>
																							<newline/>
																						</children>
																					</template>
																				</children>
																			</template>
																		</children>
																	</conditionbranch>
																	<conditionbranch>
																		<children>
																			<text fixtext="Не са намерени данни за ОЕЗ за търсеното лице"/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<newline/>
															<condition>
																<children>
																	<conditionbranch xpath="string-length(n1:ExecutionDate )&gt;0">
																		<children>
																			<text fixtext="Дата на издаване:">
																				<styles font-weight="bold"/>
																			</text>
																			<text fixtext=" "/>
																			<template match="n1:ExecutionDate" matchtype="schemagraphitem">
																				<editorproperties elementstodisplay="5"/>
																				<children>
																					<content>
																						<format string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>
																					</content>
																				</children>
																			</template>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<newline/>
														</children>
													</conditionbranch>
													<conditionbranch>
														<children>
															<newline/>
															<text fixtext="Не са намерени данни за подадените входни параметри."/>
														</children>
													</conditionbranch>
												</children>
											</condition>
										</children>
									</template>
								</children>
							</paragraph>
							<newline/>
						</children>
					</template>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<pagelayout/>
	<designfragments/>
</structure>

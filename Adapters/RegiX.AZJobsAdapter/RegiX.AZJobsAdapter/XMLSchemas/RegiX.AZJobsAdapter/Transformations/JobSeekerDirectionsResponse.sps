<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/AZ"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/AZ/JobSeekerDirectionsResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="..\JobSeekerDirectionsResponse.xsd" workingxmlfile="JobSeekerDirectionsResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Агенция по заетостта"/>									<newline/>									<text fixtext="Регистър на търсещите работа лица"/>								</children>							</paragraph>							<paragraph paragraphtag="h2">								<properties align="center"/>								<children>									<text fixtext="Справка по ЕГН/ЛНЧ за насочвания на търсещо работа лице"/>								</children>							</paragraph>							<template match="n1:JobSeekerDirectionsResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<condition>										<children>											<conditionbranch xpath="string( . ) = &apos;&apos;">												<children>													<paragraph paragraphtag="p">														<children>															<text fixtext="Няма данни в регистъра за това ЕГН/ЛНЧ."/>														</children>													</paragraph>												</children>											</conditionbranch>											<conditionbranch>												<children>													<paragraph paragraphtag="p">														<children>															<text fixtext="Общи данни за физическото лице">																<styles font-weight="bold"/>															</text>														</children>													</paragraph>													<table>														<properties border="1" width="70%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Име">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:FirstName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																					<text fixtext=" "/>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:MiddleName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																					<text fixtext=" "/>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:LastName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Идентификатор - ЕГН/ЛНЧ">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:PersonalID" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Регистрационен номер">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:RegistrationNumber" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Дата на регистрация">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:RegistrationDate" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format string="DD.MM.YYYY" datatype="date"/>																									</content>																									<text fixtext=" г."/>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="ДБТ на настоящата регистрация">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:RegistrationDBT" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Статус на регистрация">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:JobSeekerPersonData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:RegistrationStatus" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>													<newline/>													<condition>														<children>															<conditionbranch xpath="string(  n1:Directions ) = &apos;&apos;">																<children>																	<text fixtext="Няма данни за насочвания за това лице."/>																</children>															</conditionbranch>															<conditionbranch>																<children>																	<paragraph paragraphtag="p">																		<styles font-weight="bold"/>																		<children>																			<text fixtext="Данни за насочвания на търсещо работа лице"/>																		</children>																	</paragraph>																	<template match="n1:Directions" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<template match="n1:Direction" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<paragraph paragraphtag="p">																						<children>																							<autocalc xpath="position()"/>																							<text fixtext=" от "/>																							<autocalc xpath="count (  ../n1:Direction )"/>																							<text fixtext=": "/>																							<template match="n1:RegistrationNumber" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<text fixtext="Регистрационен номер: "/>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</paragraph>																					<table>																						<properties border="1"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<children>																											<tablecell>																												<properties width="154"/>																												<children>																													<text fixtext="Свободно работно място(номер)">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:FreeWorkPlace" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format datatype="string"/>																															</content>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																									<tablerow>																										<children>																											<tablecell>																												<properties width="154"/>																												<children>																													<text fixtext="Работодател">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:Employer" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format datatype="string"/>																															</content>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																									<tablerow>																										<children>																											<tablecell>																												<properties width="154"/>																												<children>																													<text fixtext="Длъжност">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:JobPosition" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format datatype="string"/>																															</content>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																									<tablerow>																										<children>																											<tablecell>																												<properties width="154"/>																												<children>																													<text fixtext="Състояние">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:State" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format datatype="string"/>																															</content>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																									<tablerow>																										<children>																											<tablecell>																												<properties width="154"/>																												<children>																													<text fixtext="Дата на резултат">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:ResultDate" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format string="DD.MM.YYYY" datatype="date"/>																															</content>																															<text fixtext=" г."/>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																		</children>																	</template>																</children>															</conditionbranch>														</children>													</condition>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>